﻿namespace EntityProfiler.Common.Protocol.Serializer {
    using System;
    using System.IO;
    using Annotations;

    /// <summary>
    /// Represents a serializer for <see cref="Message"/> to a string
    /// </summary>
    internal abstract class StringMessageSerializer : IMessageSerializer {
        private readonly TextWriter _textWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        protected StringMessageSerializer([NotNull] TextWriter textWriter) {
            if (textWriter == null) {
                throw new ArgumentNullException("textWriter");
            }

            this._textWriter = textWriter;
        }

        public void SerializeMessage([NotNull] Message message) {
            if (message == null) {
                throw new ArgumentNullException("message");
            }

            try {
                this.SerializeMessage(message, this._textWriter);
            } catch (Exception ex) {
                throw new MessageTransferException("Failed to serialize the message to the target", ex);
            }
        }

        protected abstract void SerializeMessage(Message message, TextWriter textWriter);
    }
}