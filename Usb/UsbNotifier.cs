using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Usb
{
    /// <summary>
    /// USB设备变更通知。
    /// </summary>
    public class UsbNotifier
    {
        #region Events

        #region Inserted

        public event EventHandler Inserted;

        private void OnInserted()
        {
            if(Inserted != null)
            {
                Inserted(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Removed

        public event EventHandler Removed;

        private void OnRemoved()
        {
            if (Removed != null)
            {
                Removed(this, EventArgs.Empty);
            }
        }

        #endregion

        #endregion

        #region Fields

        private readonly ManagementEventWatcher _insertWatcher;

        private readonly ManagementEventWatcher _removeWatcher;

        #endregion

        #region Constructors

        private UsbNotifier()
        {
            _insertWatcher = new ManagementEventWatcher();
            _removeWatcher = new ManagementEventWatcher();
        }

        #endregion

        #region Methods

        #region Public

        public static UsbNotifier OpenNotifier()
        {
            UsbNotifier notifier = new UsbNotifier();
            return notifier;
        }

        #endregion

        #endregion
    }
}
