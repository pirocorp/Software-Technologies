<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Key Value Pair</title>
</head>
<body>

<form>
    <div>Key Value Pairs:</div>
    <textarea rows="10" name="key-value-pairs"></textarea>
    <div>Delimiter:</div>
    <input type="text" name="delimiter"><br>
    <div>Target Key:</div>
    <input type="text" name="target-key"><br>
    <input type="submit">
</form>
<?php
if(isset($_GET['key-value-pairs']) && isset($_GET['delimiter'])&& isset($_GET['target-key'])){
    $result = [];
    $delimiter = $_GET['delimiter'];
    $kvps = array_filter(array_map('trim', explode("\n", $_GET['key-value-pairs'])));

    foreach ($kvps as $kvp){
        $tokens = array_map('trim', explode($delimiter, $kvp));
        $key = $tokens[0];
        $value = $tokens[1];
        $result[$key][] = $value;
    }

    $targetKey = $_GET['target-key'];
    $res = $result[$targetKey];
    foreach ($res as $item){
        echo "\n $item" . '<br>';
    }
}
?>
</body>
</html>