using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiseñoAppModerno.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Este método se utiliza para notificar a los suscriptores del evento PropertyChanged que una propiedad en el ViewModel ha cambiado. 
        /// Al utilizar el atributo [CallerMemberName], no es necesario especificar el nombre de la propiedad manualmente al llamar al método.
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        /* El atributo [CallerMemberName] permite obtener el nombre del miembro que llama al método sin tener que especificarlo explícitamente. 
       * Esto es útil para no tener que pasar el nombre de la propiedad que cambió manualmente al llamar al método. Si no se proporciona un nombre, 
       * el valor predeterminado será null*/
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            /*utiliza el operador de condición nula ?. para verificar si hay suscriptores (event listeners) al evento PropertyChanged. 
              Si hay suscriptores, se invoca el evento PropertyChanged pasando como argumentos:
                 this: Una referencia al objeto que llama al método (la instancia actual del ViewModel).

                 new PropertyChangedEventArgs(name): Se crea una nueva instancia de la clase PropertyChangedEventArgs, 
                    la cual contiene información sobre el evento, incluyendo el nombre de la propiedad que cambió.*/

        }
    }
}
