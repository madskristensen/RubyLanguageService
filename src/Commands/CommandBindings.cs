using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor.Commanding;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using static Microsoft.VisualStudio.VSConstants;

namespace RubyLanguageService.Commands
{
    internal sealed class CommandBindings
    {
        [Export]
        [CommandBinding(CMDSETID.StandardCommandSet2K_string, (uint)VSStd2KCmdID.COMMENT_BLOCK, typeof(CommentSelectionCommandArgs))]
        internal CommandBindingDefinition commentCommandBindings = null;

        [Export]
        [CommandBinding(CMDSETID.StandardCommandSet2K_string, (uint)VSStd2KCmdID.UNCOMMENT_BLOCK, typeof(UncommentSelectionCommandArgs))]
        internal CommandBindingDefinition uncommentCommandBindings = null;
    }
}