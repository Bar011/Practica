using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Practica.Server.Helpers
{
    public static  class IJSRuntimeExtensionMethods
    {
        public static async Task Toast(this JSRuntime js, string cTitulo, string cMensaje, string cTipo="info")
        {
            await js.InvokeVoidAsync($"toastr.{cTipo}",cMensaje,cTitulo);
        }
    }
}
