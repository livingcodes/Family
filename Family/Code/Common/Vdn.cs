namespace Family.Common;
public class Vdn {
   public Ls<Msg> msgs = new();
   public Vdn add(Msg msg) {
      msgs.add(msg);
      return this;
   }
   public Vdn err(str txt) =>
      add(new Err(txt));
   public Vdn wrn(str txt) =>
      add(new Wrn(txt));
   public Vdn inf(str txt) =>
      add(new Inf(txt));
}
public class Msg {
   public Lvl lvl;
   public str txt;
   public Msg(str txt, Lvl lvl) {
      this.lvl = lvl;
      this.txt = txt;
   }
}
public class Err : Msg {
   public Err(str txt) 
   : base(txt, Lvl.err) {}
}
public class Wrn : Msg {
   public Wrn(str txt)
   : base(txt, Lvl.wrn) {}
}
public class Inf : Msg {
   public Inf(str txt) 
   : base(txt, Lvl.inf) {}
}
public class Lvl {
   public Lvl(str txt) => 
      this.txt = txt;
   public Lvl(str txt, str typ) : this(txt) => 
      this.typ = typ;
   public str txt, typ;
   public static Lvl inf = new("info");
   public static Lvl wrn = new("warning");
   public static Lvl err = new("error");
   public static Lvl suc = new("info", "success");

   public override str ToString() => txt;
   public str str() => ToString();

   public bln eq(Lvl lvl) =>
      txt == lvl.txt
      && typ == lvl.typ;

   public static bln operator ==(Lvl x, Lvl y) =>
      x.eq(y);

   public static bln operator !=(Lvl x, Lvl y) =>
      !x.eq(y);

   public override bln Equals(obj obj) {
      if (obj is null)
         return false;
      if (obj.GetType().Name == nameof(Lvl))
         return false;
      var x = (Lvl)obj;
      return this == x;
   }
}