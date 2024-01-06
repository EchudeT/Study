from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from typing import ClassVar as _ClassVar, Optional as _Optional

DESCRIPTOR: _descriptor.FileDescriptor

class CountRequest1(_message.Message):
    __slots__ = ("num_a", "num_b", "opt")
    NUM_A_FIELD_NUMBER: _ClassVar[int]
    NUM_B_FIELD_NUMBER: _ClassVar[int]
    OPT_FIELD_NUMBER: _ClassVar[int]
    num_a: int
    num_b: int
    opt: int
    def __init__(self, num_a: _Optional[int] = ..., num_b: _Optional[int] = ..., opt: _Optional[int] = ...) -> None: ...

class CountReply(_message.Message):
    __slots__ = ("reNum",)
    RENUM_FIELD_NUMBER: _ClassVar[int]
    reNum: int
    def __init__(self, reNum: _Optional[int] = ...) -> None: ...
