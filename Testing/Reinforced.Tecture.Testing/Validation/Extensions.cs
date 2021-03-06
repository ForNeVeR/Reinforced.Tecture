﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Reinforced.Tecture.Tracing;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
namespace Reinforced.Tecture.Testing.Validation
{
    internal static class Extensions
    {
        public static ExpressionSyntax MakeEmptyChain(string storyVariableId)
        {
            return InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        IdentifierName(storyVariableId).WithLeadingTrivia(Formats.Tab, Formats.Tab, Formats.Tab),
                        IdentifierName(nameof(Trace.Begins))))
                .WithTrailingTrivia(LineFeed);
        }

        /// <summary>
        /// Makes using directive static
        /// </summary>
        /// <param name="uds">Using directive</param>
        /// <returns>Fluent</returns>
        public static UsingDirectiveSyntax Static(this UsingDirectiveSyntax uds)
        {
            return uds.WithStaticKeyword(
                Token(
                    TriviaList(),
                    SyntaxKind.StaticKeyword,
                    TriviaList(
                        Space)));
        }
    }
}
