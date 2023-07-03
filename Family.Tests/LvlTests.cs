namespace Family.Tests;
using Family.Common;
[tc]public class LvlTests : BaseTests {
   [tm]public void eq() {
      var x = Lvl.err;
      ass(Lvl.err == x);
   }
   [tm]public void noEq() {
      ass(Lvl.err != Lvl.wrn);
   }
}