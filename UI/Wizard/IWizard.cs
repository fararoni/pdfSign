using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.UI.Wizard
{
    internal interface IWizard
    {
        void SetFormBase(FormBaseWizard formBaseWizard);
        void SetStatusButtons();
    }
}
