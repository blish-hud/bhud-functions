if (IsAuth(true)) {
  var gitPull = new System.Diagnostics.Process();
  gitPull.StartInfo.WorkingDirectory = "func";
  gitPull.StartInfo.FileName         = "git";
  gitPull.StartInfo.Arguments        = "pull";

  gitPull.Start();
  await gitPull.WaitForExitAsync();
  await ResetScriptCache();
  await SetResponse("OK", 200);

  var restart = new System.Diagnostics.Process();
  restart.StartInfo.FileName  = "service";
  restart.StartInfo.Arguments = "sharpfunc restart";
  restart.Start();
} else {
  await SetResponse("NOT OK", 403);
}
