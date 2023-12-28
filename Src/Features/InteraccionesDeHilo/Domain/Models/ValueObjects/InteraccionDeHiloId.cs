using Shared.Common;

namespace InteraccionesDeHilo.Domain
{
    public record InteraccionDeHiloId:ID {

        public InteraccionDeHiloId(Guid id):base(id){}        
        private InteraccionDeHiloId()
        {
            
        }

        static public InteraccionDeHiloId Nuevo(){
            return new InteraccionDeHiloId(Guid.NewGuid());
        }
    }
}