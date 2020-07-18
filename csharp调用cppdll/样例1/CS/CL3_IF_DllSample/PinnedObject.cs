using System;
using System.Runtime.InteropServices;

namespace CL3_IF_DllSample
{
    public sealed class PinnedObject : IDisposable
    {
        private GCHandle _Handle;
        private bool _disposed;


        public IntPtr Pointer
        {
            get { return _Handle.AddrOfPinnedObject(); }
        }

        public PinnedObject(object target)
        {
            _Handle = GCHandle.Alloc(target, GCHandleType.Pinned);
        }


        public void Dispose()
        {
            CleanUp(true);
        }

        private void CleanUp(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                _Handle.Free();
                _Handle = new GCHandle();
                if(disposing)
                    GC.SuppressFinalize(this);
            }
        }

        ~PinnedObject()
        {
            CleanUp(false);
        }
    }
}
