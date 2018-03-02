<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Reverse Numbers</title>
</head>
<body>
<?php
if(isset($_GET['numbers']) && isset($_GET['delimeter'])){
    $delimeter = $_GET['delimeter'];
    $lines = $_GET['numbers'];
    $arr = array_filter(array_map('trim', explode($delimeter, $lines)));

    for ($i = count($arr) - 1; $i >= 0; $i--) {
        echo $arr[$i] . '<br>' . "\n";
    }
}
?>

<form>
    <div>Input Lines:</div>
    <span>
    <textarea rows="10" name="numbers"></textarea><br>
    </span>
    <div>Delimeter:</div>
    <span style="display: inline-block">
    <input type="text" name="delimeter">
    </span>
    <br>
    <input type="submit" value="Reverse">
</form>
</body>
</html>