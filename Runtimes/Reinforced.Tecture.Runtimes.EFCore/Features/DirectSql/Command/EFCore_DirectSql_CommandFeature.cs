﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Reinforced.Tecture.Features.SqlStroke.Infrastructure;
using Reinforced.Tecture.Query;
using Reinforced.Tecture.Runtimes.EFCore.Features.DirectSql.Runtime;

namespace Reinforced.Tecture.Runtimes.EFCore.Features.DirectSql.Command
{
    class EFCore_DirectSql_CommandFeature : Reinforced.Tecture.Features.SqlStroke.Command
    {
        internal ILazyDisposable<DbContext> Context { get; }

        public EFCore_DirectSql_CommandFeature(ILazyDisposable<DbContext> context, Type channel, InterpolatorFactory fac) 
            : base(new EfCoreStokeRuntime(context, channel, fac))
        {
            Context = context;
            
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public override void Dispose()
        {
            Context.Dispose();
        }

        protected override HashSet<Type> ServingTypes
        {
            get
            {
                if (Aux.IsCommandRunNeeded || Aux.IsEvaluationNeeded)
                {
                    return new HashSet<Type>(Context.Value.Model.GetEntityTypes().Select(x => x.ClrType));
                }
                else
                {
                    var tp = Context.ValueType;
                    var allDbSets = tp.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

                    var typeQuery = allDbSets
                        .SelectMany(x => x.PropertyType.GetGenericArguments());
                    return new HashSet<Type>(typeQuery);
                }
            }
        }
    }
}
