namespace Family;
public interface ILog {
   void Debug(string msg);
   void Info(string msg);
   void Warn(string msg);
   void Error(string msg);
   void Ex(string msg, Exception ex);
}