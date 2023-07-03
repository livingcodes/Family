namespace Family.Common;
public class Ls<T> : List<T>  {
   public int cnt => 
      Count;
   public Ls<T> add(T item) {
      Add(item);
      return this;
   }
}