extends Panel
class_name Inventory
var invgrid:GridContainer
@export var gui_scale:int
@export var inslot:Item
func _ready() -> void:
	invgrid = $Inventory
	invgrid.set_max_columns = size.x/(50*gui_scale)
	invgrid.max_rows
	var i:int
	while i < 20 :
		i=i+1
		invgrid
