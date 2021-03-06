using GammaJul.ReSharper.EnhancedTooltip.DocumentMarkup;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Psi.CodeAnnotations;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation.Highlightings.CSharp {

	[SolutionComponent]
	internal sealed class ConditionalLogicTrueFalseOperatorMissingErrorEnhancer : CSharpHighlightingEnhancer<ConditionalLogicTrueFalseOperatorMissingError> {

		protected override void AppendTooltip(ConditionalLogicTrueFalseOperatorMissingError highlighting, CSharpColorizer colorizer) {
			colorizer.AppendPlainText("The operator '");
			colorizer.AppendDeclaredElement(highlighting.SignOperator, highlighting.Substitution, PresenterOptions.QualifiedName);
			colorizer.AppendPlainText("' requires a matching operator '");
			colorizer.AppendKeyword("true");
			colorizer.AppendPlainText("'/'");
			colorizer.AppendKeyword("false");
			colorizer.AppendPlainText("' to also be defined");
		}
		
		public ConditionalLogicTrueFalseOperatorMissingErrorEnhancer(
			[NotNull] TextStyleHighlighterManager textStyleHighlighterManager,
			[NotNull] CodeAnnotationsCache codeAnnotationsCache,
			[NotNull] HighlighterIdProviderFactory highlighterIdProviderFactory)
			: base(textStyleHighlighterManager, codeAnnotationsCache, highlighterIdProviderFactory) {
		}

	}

}