<?php
define("DBVO_AUTOLOAD_PATH", "./");
require_once('Autoload.inc.php');

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