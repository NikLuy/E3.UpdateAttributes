using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace E3.UpdateAttributes.E3Connector
{
    public static class Win32
    {
        /// <summary>
        /// Returns a pointer to an implementation of IBindCtx (a bind context object).
        /// This object stores information about a particular moniker-binding operation.
        /// </summary>
        /// <param name="reserved">This parameter is reserved and must be 0.</param>
        /// <param name="ppbc">Address of an IBindCtx* pointer variable that receives
        /// the interface pointer to the new bind context object. When the function is
        /// successful, the caller is responsible for calling Release on the bind context.
        /// A NULL value for the bind context indicates that an error occurred.</param>
        /// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>

        [DllImport("ole32.dll")]
        public static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);

        /// <summary>
        /// Returns a pointer to the IRunningObjectTable
        /// interface on the local running object table (ROT).
        /// </summary>
        /// <param name="reserved">This parameter is reserved and must be 0.</param>
        /// <param name="prot">The address of an IRunningObjectTable* pointer variable
        /// that receives the interface pointer to the local ROT. When the function is
        /// successful, the caller is responsible for calling Release on the interface
        /// pointer. If an error occurs, *pprot is undefined.</param>
        /// <param name="pprot"></param>
        /// <returns>This function can return the standard return values E_UNEXPECTED and S_OK.</returns>
        [DllImport("ole32.dll")]

        public static extern int GetRunningObjectTable(uint reserved,
            out System.Runtime.InteropServices.ComTypes.IRunningObjectTable pprot);

    }
}