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

        private static readonly ManagementScope Scope;

        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(3);

        private Boolean _isStarted;

        #endregion

        #region Constructors

        static UsbNotifier()
        {
            Scope = new ManagementScope("root\\CIMV2");
            Scope.Options.EnablePrivileges = true;
        }

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
            notifier.Init();
            return notifier;
        }

        public void Open()
        {
            if (_isStarted) return;
            _insertWatcher.Start();
            _removeWatcher.Start();
        }

        public void Close()
        {
            if (!_isStarted) return;
            _insertWatcher.Stop();
            _removeWatcher.Stop();
        }

        #endregion

        #region Private

        private void Init()
        {
            WqlEventQuery insertQuery = new WqlEventQuery("__InstanceCreationEvent", Interval, "TargetInstance isa 'Win32_USBControllerDevice'");
            _insertWatcher.Scope = Scope;
            _insertWatcher.Query = insertQuery;
            _insertWatcher.EventArrived += _insertWatcher_EventArrived;
            _insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("__InstanceDeletionEvent", Interval, "TargetInstance isa 'Win32_USBControllerDevice'");
            _removeWatcher.Scope = Scope;
            _removeWatcher.Query = removeQuery;
            _removeWatcher.EventArrived += _removeWatcher_EventArrived;
            _removeWatcher.Start();

            _isStarted = true;
        }

        private void _removeWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            OnRemoved();
        }

        private void _insertWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            OnInserted();
        }

        #endregion

        #endregion
    }
}
