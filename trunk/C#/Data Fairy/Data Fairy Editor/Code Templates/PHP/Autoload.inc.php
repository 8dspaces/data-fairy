<?php
// usage:
// define("DBVO_AUTOLOAD_PATH", "data/");
// require_once('Autoload.inc.php');

function __autoload($CLASS_NAME) {

	$path = '';
	if(defined('DBVO_AUTOLOAD_PATH'))
		$path = DBVO_AUTOLOAD_PATH;

	$file = $CLASS_NAME . '.class.php';

	if(file_exists($path . 'base/' . $file)) {
		require_once($path . 'base/' . $file);
		return;
	}

	if(file_exists($path . 'dbvos/' . $file)) {
		require_once($path . 'dbvos/' . $file);
		return;
	}

	if(file_exists($path . 'enums/' . $file)) {
		require_once($path . 'enums/' . $file);
		return;
	}

	if(file_exists($path . 'interfaces/' . $file)) {
		require_once($path . 'interfaces/' . $file);
		return;
	}

	if(file_exists($path . 'tables/' . $file)) {
		require_once($path . 'tables/' . $file);
		return;
	}

	throw new Exception("Unable to find class file " . $file . " for type " . $CLASS_NAME);
}