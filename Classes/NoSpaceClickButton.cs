using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm.Classes
{
    public class NoSpaceClickButton : Button
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Ignore the Space key press
            if (keyData == Keys.Space)
            {
                return true; // Return true to indicate the key has been handled
            }

            // Otherwise, use the default processing
            return base.ProcessDialogKey(keyData);
        }
    }
}
