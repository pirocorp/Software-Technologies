<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Array Indexes</title>
</head>
<body>
    <div>Input Lines:</div>
    <form>
        <textarea rows="10" name="key-value-pairs"></textarea>
        <div>Delimiter:</div>
        <input type="text" name="delimiter">
        <div>Array Size:</div>
        <input type="number" name="array-size">
        <input type="submit">
    </form>
    <?php
    if(isset($_GET['key-value-pairs']) && isset($_GET['delimiter']) && isset($_GET['array-size'])){
        $result = [];
        $arrSize = intval($_GET['array-size']);
        for ($i = 0; $i < $arrSize; $i++) {
            $result[] = 0;
        }
        $kvps = array_filter(array_map('trim', explode("\n", $_GET['key-value-pairs'])));
        foreach ($kvps as $kvp){
            $customDelimiter = $_GET['delimiter'];
            $tokens = explode($customDelimiter, $kvp);
            $index = $tokens[0];
            $value = $tokens[1];
            $index = intval($index);
            $value = intval($value);
            $result[$index] = $value;
        }
        foreach ($result as $res){
            echo "\n" . "$res" . '<br>';
        }
    }
    ?>
</body>
</html>