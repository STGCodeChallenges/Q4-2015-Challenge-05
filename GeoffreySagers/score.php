<?php require("db.php"); ?>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title><?=$title;?></title>
<link href="css/styles.css" rel="stylesheet" type="text/css">
</head>

<body>
<?php
    $responses = array();
    $question = array();
    $correct = array();
    $score=0;
    $color = "#000000";

foreach($_POST as $key => $value)
{
   $$key = $value;
   $responses[] = $value;
}
$offset = 0;
if($difficulty == "Easy"){
    foreach($easy as $questionlist){
        $question[$offset] = $questionlist["question"];
        $correct[$offset] = $questionlist["answer"][0];
        $offset++;
    }    
}

if($difficulty == "Hard"){
    foreach($hard as $questionlist){
        $question[$offset] = $questionlist["question"];
        $correct[$offset] = $questionlist["answer"][0];
        $offset++;
    }    
}

?>
<div class="questionbox">
    <h2 class="ctr"><?=$title;?></h2>
    <?php 
    echo("<ol>");
    for($x=0;$x<5;$x++){
        if($responses[$x]===$correct[$x]){
            $score +=1;
            $color = "#009900";
        }   
        echo("<li>" . $question[$x]."?");
        echo("<ul>");
        echo("<li style='color:$color'>Your answer: ");
        echo($responses[$x]);
        echo("</li><li>");
        echo("Correct answer: ");
        echo($correct[$x]);
        echo("</li></ul>"); 
        $color = "#000000";
    }
    echo("</ol>");
    ?>
    <h3 class="ctr">Your final score is <?= $score; ?>/5</h3>
    <p class="ctr"><a href="index.php" class="btn">Play Again?</a></p>
</div>
</body>
</html>