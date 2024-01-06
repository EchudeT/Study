from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from typing import ClassVar as _ClassVar, Optional as _Optional

DESCRIPTOR: _descriptor.FileDescriptor

class CountRequest(_message.Message):
    __slots__ = ("numa", "numb", "opt")
    NUMA_FIELD_NUMBER: _ClassVar[int]
    NUMB_FIELD_NUMBER: _ClassVar[int]
    OPT_FIELD_NUMBER: _ClassVar[int]
    numa: int
    numb: int
    opt: int
    def __init__(self, numa: _Optional[int] = ..., numb: _Optional[int] = ..., opt: _Optional[int] = ...) -> None: ...

class CountReply(_message.Message):
    __slots__ = ("reNum",)
    RENUM_FIELD_NUMBER: _ClassVar[int]
    reNum: int
    def __init__(self, reNum: _Optional[int] = ...) -> None: ...
