# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: link.proto
# Protobuf Python Version: 4.25.0
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
from google.protobuf.internal import builder as _builder
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\nlink.proto\x12\tCountPack\":\n\rCountRequest1\x12\r\n\x05num_a\x18\x01 \x01(\x05\x12\r\n\x05num_b\x18\x02 \x01(\x05\x12\x0b\n\x03opt\x18\x03 \x01(\x05\"\x1b\n\nCountReply\x12\r\n\x05reNum\x18\x01 \x01(\x05\x32\x8e\x01\n\x05\x43ount\x12\x41\n\x0cLotsofCounts\x12\x18.CountPack.CountRequest1\x1a\x15.CountPack.CountReply0\x01\x12\x42\n\x0bQuickCounts\x12\x18.CountPack.CountRequest1\x1a\x15.CountPack.CountReply(\x01\x30\x01\x62\x06proto3')

_globals = globals()
_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, _globals)
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'link_pb2', _globals)
if _descriptor._USE_C_DESCRIPTORS == False:
  DESCRIPTOR._options = None
  _globals['_COUNTREQUEST1']._serialized_start=25
  _globals['_COUNTREQUEST1']._serialized_end=83
  _globals['_COUNTREPLY']._serialized_start=85
  _globals['_COUNTREPLY']._serialized_end=112
  _globals['_COUNT']._serialized_start=115
  _globals['_COUNT']._serialized_end=257
# @@protoc_insertion_point(module_scope)
