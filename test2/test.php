<?php
putenv('GOOGLE_APPLICATION_CREDENTIALS=./creds.json');

/**
 * Sample PHP code for youtube.captions.download
 * See instructions for running these code samples locally:
 * https://developers.google.com/explorer-help/guides/code_samples#php
 *
 * Also note that this sample code downloads a file and can't be executed
 * via this interface. To test this sample, you must run it locally using your
 * own API credentials.
 */

if (!file_exists(__DIR__ . '/vendor/autoload.php')) {
  throw new Exception(sprintf('Please run "composer require google/apiclient:~2.0" in "%s"', __DIR__));
}
require_once __DIR__ . '/vendor/autoload.php';

$client = new Google_Client();
$client->setApplicationName('API code samples');
$client->setScopes([
  'https://www.googleapis.com/auth/youtube.force-ssl',
]);

$client->useApplicationDefaultCredentials();

// Get the authorized Guzzle HTTP client.
$http = $client->authorize();

$service = new Google_Service_YouTube($client);
$response = $service->captions->listCaptions('snippet', 'RmN7ZYO9PRk');
print_r($response);

$response = $http->request(
  'GET',
  '/youtube/v3/captions/2GQZwKA6gJQ9MwGO0YqfGp5wSf_H9hn5TbghUOwS5AY=');
print_r($response);

