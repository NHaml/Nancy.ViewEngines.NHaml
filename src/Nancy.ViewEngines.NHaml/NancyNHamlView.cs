namespace Nancy.ViewEngines.NHaml
{
    using global::System.Web.NHaml.TemplateResolution;

    public class NancyNHamlView : StreamViewSource
    {
        public NancyNHamlView(ViewLocationResult viewLocationResult)
            : base(viewLocationResult.Contents.Invoke(),
            GetSafeViewPath(viewLocationResult))
        { }

        private static string GetSafeViewPath(ViewLocationResult viewLocation)
        {
            var result = string.IsNullOrEmpty(viewLocation.Location) ? string.Concat(viewLocation.Name, ".", viewLocation.Extension) : string.Concat(viewLocation.Location, "/", viewLocation.Name, ".", viewLocation.Extension);
            return result.Replace("/", "\\");
        }
    }
}
