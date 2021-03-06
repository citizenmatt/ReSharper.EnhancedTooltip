using GammaJul.ReSharper.EnhancedTooltip.DocumentMarkup;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeAnnotations;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation.Highlightings.CSharp {

	[SolutionComponent]
	internal sealed class CannotAccessExplicitImplementationErrorEnhancer : CSharpHighlightingEnhancer<CannotAccessExplicitImplementationError> {

		protected override void AppendTooltip(CannotAccessExplicitImplementationError highlighting, CSharpColorizer colorizer) {
			IExplicitImplementation explicitImplementation = highlighting.ExplicitImplementation;
			OverridableMemberInstance resolvedMember = explicitImplementation.Resolve();

			colorizer.AppendPlainText("Cannot access explicit implementation of '");
			colorizer.AppendExpressionType(explicitImplementation.DeclaringType, false, PresenterOptions.NameOnly);
			colorizer.AppendOperator(".");
			if (resolvedMember != null)
				colorizer.AppendDeclaredElement(resolvedMember.Element, resolvedMember.Substitution, PresenterOptions.NameOnly);
			else
				colorizer.AppendPlainText(explicitImplementation.MemberName);
			colorizer.AppendPlainText("'");
		}
		
		public CannotAccessExplicitImplementationErrorEnhancer(
			[NotNull] TextStyleHighlighterManager textStyleHighlighterManager,
			[NotNull] CodeAnnotationsCache codeAnnotationsCache,
			[NotNull] HighlighterIdProviderFactory highlighterIdProviderFactory)
			: base(textStyleHighlighterManager, codeAnnotationsCache, highlighterIdProviderFactory) {
		}

	}

}