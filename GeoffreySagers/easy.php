<?php require("db.php"); ?>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><?=$title;?></title>
<link href="css/styles.css" rel="stylesheet" type="text/css">
</head>

<body>
<div class="questionbox">
    <h2 class="ctr"><?=$title;?></h2>
    <form action="score.php" method="post">
    <?php
    echo("<ol>");
    $x=1;
    foreach($easy as $questionlist){
        shuffle($questionlist["answer"]);
        echo("<li>" . $questionlist["question"]."?");
        echo("<ul>");
        echo("<li><label><input type='radio' name='question" . $x . "' value='" . $questionlist["answer"][0] . "'>" . $questionlist["answer"][0]."</label></li>");
        echo("<li><label><input type='radio' name='question" . $x . "' value='" . $questionlist["answer"][1] . "'>" . $questionlist["answer"][1]."</label></li>");
        echo("<li><label><input type='radio' name='question" . $x . "' value='" . $questionlist["answer"][2] . "'>" . $questionlist["answer"][2]."</label></li>");
        echo("<li><label><input type='radio' name='question" . $x . "' value='" . $questionlist["answer"][3] . "'>" . $questionlist["answer"][3]."</label></li>");
        echo("</ul>");
        echo("</li>");
        $x++;
        }
    echo("</ol>");
    ?>
    <input type="hidden"  name="difficulty" id="difficulty" value="Easy" />
    <input type="submit" />
    </form>
</div>
</body>
</html>