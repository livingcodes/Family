namespace Family.Scripts;
[tc]public class ExportTests
{
  [tm]public void Export() {
    int treeId = 1;
    var db = new Family.Data.Db();
    var mbrs = db.sel<Member>();
    var tree = db.selId<Tree>(treeId);
    var itms = db.sel<TreeItem>(
      "WHERE treeId = @treeId", treeId);
    var exporter = new Exporter();
    var export = new Export() {
      Mbr = mbrs, Tre = tree, Itm = itms
    };
    str path = @"c:\code\export.txt";
    exporter.Export(export, path);
  }

  [tm]public void Dslz1() {
    str fp = @"c:\code\export.txt";
    str jsn = File.ReadAllText(fp);
    var exp = Common.Common.Dslz<Export>(jsn);
    Assert.IsTrue(exp.Mbr.Count > 1);
  }
}