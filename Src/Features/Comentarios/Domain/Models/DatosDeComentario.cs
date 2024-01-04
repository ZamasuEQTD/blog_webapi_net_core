namespace Comentarios.Domain
{
    public class DatosDeComentario
    {
        public TagDeComentario Tag {get;private set;}
        public string Color {get;private set;}
        public TagUnico? TagUnico{get;private set;}
        public int? Dados {get;private set;}

        private DatosDeComentario(){}
        public DatosDeComentario(TagDeComentario tag,string color, TagUnico? tagUnico = null,int? dados=null)
        {
            Tag = tag;
            Color = color;
            TagUnico = tagUnico;
            Dados = dados;    
        }
    }
}