namespace Domain.Core.Entities.Auditing
{
    public class App
    {
        public Int32? IdParent { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public App() { }

        public App(Int32? IdParent, string? Title, string? Description)
        {
            this.IdParent = IdParent;
            this.Title = Title;
            this.Description = Description;
        }
    }
}
