if (IsAuth(true)) {
  var gitPull = new System.Diagnostics.Process();
  gitPull.StartInfo.WorkingDirectory = "func";
  gitPull.StartInfo.FileName         = "git";
  gitPull.StartInfo.Arguments        = "pull";

  gitPull.Start();
  await gitPull.WaitForExitAsync();
  await ResetScriptCache();
  await SetResponse("OK", 200);
} else {
  await SetResponse("NOT OK", 403);
}
