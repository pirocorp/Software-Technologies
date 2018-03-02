<!doctype html>
<head>
    <meta charset="UTF-8">
    <title>Document</title>
</head>
<body>
    <form>
        <textarea rows="10" name="lines"></textarea>
        <br>
        <input type="submit">
    </form>

    <?php
    if(isset($_GET['lines'])){
        $lines = $_GET['lines'];
        $arr = array_filter(array_map('trim', explode("\n", $lines)));

        for ($i = 0; $i < count($arr); $i++){
            if($arr[$i] == 'Stop'){
                break;
            }
            echo $arr[$i] . '<br>';
        }
    }

    ?>
</body>
</html>