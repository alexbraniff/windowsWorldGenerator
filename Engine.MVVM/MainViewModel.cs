using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.MVVM
{
    public class MainViewModel : BaseViewModel
    {
        private bool enableButtons = false;
        public bool EnableButtons
        {
            set
            {
                if (Set(ref enableButtons, value))
                {
                    RaisePropertyChanged(nameof(EnableEnvironmentButtons));
                }
            }
            get { return enableButtons; }
        }

        private bool enableEnvironmentButtons = true;
        public bool EnableEnvironmentButtons
        {
            set
            {
                Set(ref enableEnvironmentButtons, value);
            }
            get { return enableEnvironmentButtons && enableButtons; }
        }
    }
}
