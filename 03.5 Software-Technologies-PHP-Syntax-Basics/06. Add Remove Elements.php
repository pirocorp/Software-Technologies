<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Document</title>
</head>
<body>
<div>Commands:</div>
<form>
    <textarea rows="10" name="commands"></textarea>
    <div>Delimiter:</div>
    <input type="text" name="delimiter"><br>
    <input type="submit">
</form>
<?php
if(isset($_GET['commands']) && isset($_GET['delimiter'])){
    $result = [];
    $delimiter = $_GET['delimiter'];
    $commands = array_filter(array_map('trim', explode("\n", $_GET['commands'])));

    foreach ($commands as $command){
        $tokens = array_map('trim', explode($delimiter, $command));
        $command = $tokens[0];
        $value = $tokens[1];
        if($command == "add"){
            $result[] = $value;
        }
        else{
            array_splice($result, $value, 1);
        }
    }

    foreach ($result as $item){
        echo "\n$item" . '<br>';
    }
}
?>
</body>
</html>