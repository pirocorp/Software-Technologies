<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Object to JSON String</title>
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
    protected $surname;
    protected $age;
    protected $grade;
    protected $date;
    protected $town;

    function __construct($name, $surname, $age, $grade, $date, $town)
    {
        $this->name = $name;
        $this->surname = $surname;
        $this->age = $age;
        $this->grade = $grade;
        $this->date = $date;
        $this->town = $town;
    }

    public function __toString()
    {
        return "Name: $this->name; Surname: $this->surname; Age: $this->age; Grade: $this->grade; Date: $this->date; Town: $this->town;";
    }

    function getName()
    {
        return $this->name;
    }

    function setName($name)
    {
        return $this->name = $name;
    }

    function getSurname()
    {
        return $this->surname;
    }

    function setSurname($surname)
    {
        return $this->surname = $surname;
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

    function getDate()
    {
        return $this->date;
    }

    function setDate($date)
    {
        return $this->date = $date;
    }

    function getTown()
    {
        return $this->town;
    }

    function setTown($town)
    {
        return $this->town = $town;
    }
}
    if(isset($_GET['input']) && isset($_GET['delimiter'])) {
        $result = [];
        $listOfStudents = [];
        $delimiter = $_GET['delimiter'];
        $items = array_filter(array_map('trim', explode("\n", $_GET['input'])));

        foreach ($items as $item) {
            $tokens = array_map('trim', explode($delimiter, $item));
            $item_id = $tokens[0];
            $item_value = $tokens[1];
            $result[$item_id][] = $item_value;
        }

        $students = 0;
        foreach ($result as $res){
            $count = count($res);

            if($count > $students)
            {
                $students = $count;
            }
        }

        for ($i = 0; $i < $students; $i++) {
            $name = $result['name'][$i];
            $surname = $result['surname'][$i];
            $age = $result['age'][$i];
            $grade = $result['grade'][$i];
            $date = $result['date'][$i];
            $town = $result['town'][$i];
            $currentStudent = new Student($name, $surname, $age, $grade, $date, $town);
            $currentArr = array();
            $currentArr['name'] = $name;
            $currentArr['surname'] = $surname;
            $currentArr['age'] = $age;
            $currentArr['grade'] = $grade;
            $currentArr['date'] = $date;
            $currentArr['town'] = $town;
            $listOfStudents[] = json_encode($currentArr, JSON_UNESCAPED_SLASHES);
        }

        foreach ($listOfStudents as $student){
            echo $student;
        }
    }
?>
</body>
</html>