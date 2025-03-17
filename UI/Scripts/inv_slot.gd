extends Container
@export var item:Item
@export var amount:int
func _ready() -> void:
	$VBoxContainer/TextureRect.texture = item.texure
	$VBoxContainer/TextureRect.custom_minimum_size=Vector2(32*Settings.gui_scale,32*Settings.gui_scale)
	$VBoxContainer/HBoxContainer/Count.label_settings.font_size = 8*Settings.gui_scale
	if (item.cap>1):$VBoxContainer/HBoxContainer/Count.text = str(amount,"/",item.cap)
	else : $VBoxContainer/HBoxContainer/Count.text= ""
	custom_minimum_size = Vector2(50*Settings.gui_scale,50*Settings.gui_scale)
