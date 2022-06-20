namespace Family;

public class Log : ILog {
   ILogger logger;
   public Log(ILogger logger) {
      this.logger = logger;
   }

   public void Debug(string msg) {
      System.Diagnostics.Debug.WriteLine(msg);
      logger.LogDebug(msg);
   }

   public void Info(string msg) =>
      logger.LogInformation(msg);

   public void Warn(string msg) =>
      logger.LogWarning(msg);

   public void Error(string msg) =>
      logger.LogError(msg);

   public void Ex(string msg, Exception ex) =>
      logger.LogError(ex, msg);
}