extends Container
@export var item:Item
@export var amount:int
func _ready() -> void:
	$VBoxContainer/TextureRect.texture = item.texure
	if (item.cap>1):$VBoxContainer/HBoxContainer/Count.text = str(amount,"/",item.cap)
	else : $VBoxContainer/HBoxContainer/Count.text= ""
