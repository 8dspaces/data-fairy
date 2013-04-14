<?php
function __autoload($class_name) {
	$file = $class_name . '.class.php';

	if(file_exists('base/' . $file)) {
		require_once('base/' . $file);
		return;
	}

	if(file_exists('dbvos/' . $file)) {
		require_once('dbvos/' . $file);
		return;
	}

	if(file_exists('enums/' . $file)) {
		require_once('enums/' . $file);
		return;
	}

	if(file_exists('interfaces/' . $file)) {
		require_once('interfaces/' . $file);
		return;
	}

	if(file_exists('tables/' . $file)) {
		require_once('tables/' . $file);
		return;
	}

	throw new Exception("Unable to find class file " . $file . " for type " . $class_name);
}

class AutoTests
{
	public function __construct()
	{
		$model = new DBVOsModel();
		foreach($model->tableList as $table)
		{
			print ("<p>Table: " . $table->tableName . ", Rows: " . count($table->rowList) . "</p>");
		}
	}		
}

$test = new AutoTests();