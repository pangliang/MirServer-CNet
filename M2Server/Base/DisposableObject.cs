using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Base
{
    public abstract class DisposableObject : IDisposable
    {
        protected abstract void Dispose(bool disposing);

        ~DisposableObject()
        {
            this.Dispose(false);
        }

        protected void ExplicitDispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            this.ExplicitDispose();
        }
    }
}
