extends Control
@export var item:Item
@export var amount:int
@export var toltip:PackedScene
func _ready() -> void:
	$ItemSlot/VBoxContainer/TextureRect.texture = item.texure
	$ItemSlot/VBoxContainer/TextureRect.custom_minimum_size=Vector2(32*Settings.gui_scale,32*Settings.gui_scale)
	$ItemSlot/VBoxContainer/HBoxContainer/Count.label_settings.font_size = 8*Settings.gui_scale
	if (item.cap>1):$ItemSlot/VBoxContainer/HBoxContainer/Count.text = str(amount,"/",item.cap)
	else : $ItemSlot/VBoxContainer/HBoxContainer/Count.text= ""
	custom_minimum_size = Vector2(50*Settings.gui_scale,50*Settings.gui_scale)
	self.theme.default_font_size=8*Settings.gui_scale
	

func _make_custom_tooltip(_for_text: String) -> Object:
	var tip = toltip.instantiate()
	var desc = tip.get_child(0)
	desc.add_text(str(item.name,"\n"))
	match item.type:
		0:
			desc.add_text(str("Weapon\n"))
			if(item.ammo!=null):
				desc.add_text(str("Damage Multiplier: ",item.dmg[0],"/",item.dmg[1],"/",item.dmg[2],"\n"))
				desc.add_text(str("Ammo: ",item.ammo.name,"\n"))
			else:
				desc.add_text(str("Damage",item.dmg[0],"/",item.dmg[1],"/",item.dmg[2],"\n"))
			desc.add_text(str("Pierce : ",item.pierce,"\n"))
			desc.add_text(str("Value : ",item.value,"\n"))
			desc.add_text(str("Weight : ",item.weight,"\n"))
		1:
			desc.add_text(str("Ammo\n"))
			desc.add_text(str("Damage : ",item.dmg[0],"/",item.dmg[1],"/",item.dmg[2],"\n"))
			desc.add_text(str("Pierce : ",item.pierce,"\n"))
			desc.add_text(str("Value : ",item.value,"\n"))
			desc.add_text(str("Weight : ",item.weight,"\n"))
		2:
			desc.add_text(str("Armor\n"))
			desc.add_text(str("Defence : ",item.dmg[0],"/",item.dmg[1],"/",item.dmg[2],"\n"))
			desc.add_text(str("Resistance : ",item.pierce,"\n"))
			desc.add_text(str("Value : ",item.value,"\n"))
			desc.add_text(str("Weight : ",item.weight,"\n"))
		3:
			desc.add_text(str("Shield\n"))
			desc.add_text(str("Defence : ",item.dmg[0],"/",item.dmg[1],"/",item.dmg[2],"\n"))
			desc.add_text(str("Resistance : ",item.pierce,"\n"))
			desc.add_text(str("Value : ",item.value,"\n"))
			desc.add_text(str("Weight : ",item.weight,"\n"))
		4:
			desc.add_text(str("Resourse\n"))
			desc.add_text(str("Value : ",item.value,"\n"))
			desc.add_text(str("Weight : ",item.weight,"\n"))
	return tip
