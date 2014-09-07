<?php

abstract class PropertyObject
{
  public function __get(${NAME})
  {
    if (method_exists($this, ($method = 'get_'.${NAME})))
    {
      return $this->$method();
    }
    else return;
  }
  
  public function __isset(${NAME})
  {
    if (method_exists($this, ($method = 'isset_'.${NAME})))
    {
      return $this->$method();
    }
    else return;
  }
  
  public function __set(${NAME}, ${VALUE})
  {
    if (method_exists($this, ($method = 'set_'.${NAME})))
    {
      $this->$method(${VALUE});
    }
  }
  
  public function __unset(${NAME})
  {
    if (method_exists($this, ($method = 'unset_'.${NAME})))
    {
      $this->$method();
    }
  }
}
