namespace Family;
public class Exporter
{
  public void Export(Export export, str path) {
    str jsn = Slz(export);
    File.WriteAllText(path, jsn);
  }

  public Export Import(str jsn) {
    var export = Dslz<Export>(jsn);
    return export;
  }
}