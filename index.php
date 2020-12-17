<?php

# YouTube Transcriber
# http://techlead.tech/ytcaption/

function encodeURIComponent($str) {
  # https://stackoverflow.com/questions/1734250/what-is-the-equivalent-of-javascripts-encodeuricomponent-in-php
  $revert = array('%21'=>'!', '%2A'=>'*', '%27'=>"'", '%28'=>'(', '%29'=>')');
  return strtr(rawurlencode($str), $revert);
}

$code = <<<EOF
var regexp = new RegExp(/playerCaptionsTracklistRenderer.*?(youtube.com\/api\/timedtext.*?)"/);
var match = regexp.exec(document.body.innerHTML);
if (!match) {
  alert ("No captions found");
  return;
}
var url = regexp.exec(document.body.innerHTML)[1];
open("http://techlead.tech/ytcaption/caption.php?url=" + encodeURIComponent(url));
EOF;

$code = encodeURIComponent($code);
print <<<EOF
<head>
	<title> YouTube Transcriber</title>
	<style>
body {
  font-family:arial;
  padding: 16px;
}
</style>
</head>
<body>
	<h3> YouTube Transcriber Bookmarklet</h3>
Drag the below "link" into the bookmark bar in any browser.
Then when you're viewing a YouTube video, click it to view the transcription of the video.

	<BR/>
	<table style='border-radius:8px;font-size:15px;border:1px #ccc solid; background-color:#fafafa;padding:8px;margin:8px'>
		<tr>
			<TD>
				<a href="javascript:(function(){ $code })()">📺 Transcribe</a> (Drag to bookmark bar)
			</td>
		</tr>
	</table>
	<li> Bug notes - The video page needs to be refreshed for subsequent videos.

	</body>
EOF;
