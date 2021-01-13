using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
[CLSCompliant(false)]
class GenericResponse<T>
{
    public bool success { get; set; }
    public string message { get; set; }
    public T data { get; set; }
    public string token { get; set; }
    public GenericResponse()
    {
        
    }
}

