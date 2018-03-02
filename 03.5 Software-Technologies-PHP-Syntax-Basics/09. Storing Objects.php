<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Storing Objects</title>
</head>
<body>

<form>
    <div>Input:</div>
    <textarea rows="10" name="input"></textarea>
    <div>Delimiter:</div>
    <input type="text" name="delimiter"><br>
    <input type="submit">
</form>
<?php

class Student
{
    protected $name;
    protected $age;
    protected $grade;

    function __construct($name, $age, $grade)
    {
        $this->name = $name;
        $this->age = $age;
        $this->grade = $grade;
    }

    public function __toString()
    {
        return "Name: $this->name; Age: $this->age; Grade: $this->grade;";
    }

    function getName()
    {
        return $this->name;
    }

    function setName($name)
    {
        return $this->name = $name;
    }

    function getAge()
    {
        return $this->age;
    }

    function setAge($age)
    {
        return $this->age = $age;
    }

    function getGrade()
    {
        return $this->grade;
    }

    function setGrade($grade)
    {
        return $this->grade = $grade;
    }
}

if(isset($_GET['input']) && isset($_GET['delimiter'])) {
    $result = [];
    $delimiter = $_GET['delimiter'];
    $objects = array_filter(array_map('trim', explode("\n", $_GET['input'])));

    foreach ($objects as $object) {
        $tokens = array_map('trim', explode($delimiter, $object));
        $studentName = $tokens[0];
        $studentAge = $tokens[1];
        $studentGrade = $tokens[2];
        $currentStudent = new Student($studentName, $studentAge, $studentGrade);
        $result[] = $currentStudent;
    }

    foreach ($result as $student){
        $studentName = $student->getName();
        $studentAge = $student->getAge();
        $studentGrade = $student->getGrade();
        echo '<ul>';
        echo"<li>Name: $studentName</li>";
        echo"<li>Age: $studentAge</li>";
        echo"<li>Grade: $studentGrade</li>";
        echo '</ul>';
    }
}
?>
</body>
</html>