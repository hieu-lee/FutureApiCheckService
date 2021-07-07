<h1>FutureApiCheckService</h1>

<p>This is a service to keep the Apis of FutureMe working</p>
<p>To install and run the service on your PC, following these following steps:</p>
<ol>
  <li>Download the FutureMeApiCheckService.rar file found in the Release section of the repo and extract it, after extracting you can delete the .rar file</li>
  <li>Open Powershell as administration</li>
  <li>
    Type the command:<br/>
    <code>sc.exe create FutureMeApiCheckService binPath=$path/ApiCheckService.exe start=auto</code><br/>
    <strong>Remember to replace <code>$path</code> with the path to the folder FutureMeApiCheckService after extracting</strong>
  </li>
  <li>Press the Windows button on your keyboard, type "Services" and open Services</li>
  <li>Find the service FutureMeApiCheckService, right click on it and choose Start to start the service</li>
</ol>
