﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTS2.SimAntics
{
    public class VMSleepContinueHandler : VMContinueHandler
    {
        public uint TargetTick = 0;
        VMStack _stack;

        public VMSleepContinueHandler(VMStack stack, uint ticks, bool allowPush = false)
        {
            _stack = stack;
            var vm = _stack.Entity.VM;
            TargetTick = vm.CurrentTick + ticks;
        }

        public override VMExitCode Tick()
        {
            if (_stack.Interrupted)
                return VMExitCode.True;
            if (_stack.Entity.VM.CurrentTick >= TargetTick)
                return VMExitCode.True;
            return VMExitCode.Continue;
        }
    }
}
