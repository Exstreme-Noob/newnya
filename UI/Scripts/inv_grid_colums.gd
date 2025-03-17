extends Control
class_name Inventory
@export var invgrid:GridContainer
@export var inslot:PackedScene

func _ready() -> void:
	invgrid.columns = int(size.x/(50*Settings.gui_scale+5))
	var margin:int = int((size.x - (50*Settings.gui_scale+5)*invgrid.columns)/2)
	$"MarginContainer".add_theme_constant_override("margin_left", margin)
	var i:int
	while i < 500 :
		i=i+1
		add_item(ItemsList.Items[2],i)

func _on_window_resized():
	size.y= get_viewport().get_rect().size.y
	invgrid.columns = int(size.x/(50*Settings.gui_scale+5))
	var margin:int = int((size.x - (50*Settings.gui_scale+5)*invgrid.columns)/2)
	$"MarginContainer".add_theme_constant_override("margin_left", margin)

func add_item(item:Item,amount:int):
		var slot =inslot.instantiate()
		slot.item = item
		slot.amount = amount
		invgrid.add_child(slot)
	
