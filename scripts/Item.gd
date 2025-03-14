extends Resource
class_name Item
@export var name:String
@export_enum("weapon","ammo","armor","shield","resourse") var type: int
@export var value:int
@export var weight:int
@export var pierce:float
@export var speed:float
@export var dmg : Array[float]
@export var cap:int
@export var ammo:Item
@export var texure:Texture
