﻿using System;
using AngleSharp.DOM.Collections;
using AngleSharp.DOM.Css;
using AngleSharp.Html;
using System.Collections.Generic;

namespace AngleSharp.DOM.Html
{
    /// <summary>
    /// Represents an HTML document.
    /// </summary>
    [DOM("HTMLDocument")]
    public sealed class HTMLDocument : Document, IHTMLDocument
    {
        #region Members

        Boolean _embedded;
        Boolean _scripting;
        Cookie _cookie;

        HTMLLiveCollection<Element> _all;
        HTMLLiveCollection<HTMLFormElement> _forms;
        HTMLLiveCollection<HTMLScriptElement> _scripts;
        HTMLLiveCollection<HTMLImageElement> _images;
        HTMLLiveCollectionWithAttr<HTMLAnchorElement> _anchors;
        HTMLLiveCollection<HTMLEmbedElement, HTMLObjectElement, HTMLAppletElement> _embeds;
        HTMLLiveCollectionWithAttr<HTMLAnchorElement, HTMLAreaElement> _links;

        #endregion

        #region Events

        //Internal for now until connected properly.

        [DOM("onabort")]
        internal event EventHandler OnAbort;
        [DOM("onblur")]
        internal event EventHandler OnBlur;
        [DOM("oncanplay")]
        internal event EventHandler OnCanPlay;
        [DOM("oncanplaythrough")]
        internal event EventHandler OnCanPlayThrough;
        [DOM("onchange")]
        internal event EventHandler OnChange;
        [DOM("onclick")]
        internal event EventHandler OnClick;
        [DOM("oncontextmenu")]
        internal event EventHandler OnContextMenu;
        [DOM("oncopy")]
        internal event EventHandler OnCopy;
        [DOM("oncuechange")]
        internal event EventHandler OnCueChange;
        [DOM("oncut")]
        internal event EventHandler OnCut;
        [DOM("ondblclick")]
        internal event EventHandler OnDblClick;
        [DOM("onaondragbort")]
        internal event EventHandler OnDrag;
        [DOM("ondragend")]
        internal event EventHandler OnDragEnd;
        [DOM("ondragenter")]
        internal event EventHandler OnDragEnter;
        [DOM("ondragleave")]
        internal event EventHandler OnDragLeave;
        [DOM("ondragover")]
        internal event EventHandler OnDragOver;
        [DOM("ondragstart")]
        internal event EventHandler OnDragStart;
        [DOM("ondrop")]
        internal event EventHandler OnDrop;
        [DOM("ondurationchange")]
        internal event EventHandler OnDurationChange;
        [DOM("onemptied")]
        internal event EventHandler OnEmptied;
        [DOM("onended")]
        internal event EventHandler OnEnded;
        [DOM("onerror")]
        internal event EventHandler OnError;
        [DOM("onfocus")]
        internal event EventHandler OnFocus;
        [DOM("onfocusin")]
        internal event EventHandler OnFocusIn;
        [DOM("onfocusout")]
        internal event EventHandler OnFocusOut;
        [DOM("onfullscreenchange")]
        internal event EventHandler OnFullScreenChange;
        [DOM("onfullscreenerror")]
        internal event EventHandler OnFullScreenError;
        [DOM("oninput")]
        internal event EventHandler OnInput;
        [DOM("oninvalid")]
        internal event EventHandler OnInvalid;
        [DOM("onkeydown")]
        internal event EventHandler OnKeyDown;
        [DOM("onkeypress")]
        internal event EventHandler OnKeyPress;
        [DOM("onkeyup")]
        internal event EventHandler OnKeyUp;
        [DOM("onload")]
        internal event EventHandler OnLoad;
        [DOM("onloadeddata")]
        internal event EventHandler OnLoadedData;
        [DOM("onloadedmetadata")]
        internal event EventHandler OnLoadedMetaData;
        [DOM("onloadstart")]
        internal event EventHandler OnLoadStart;
        [DOM("onmousedown")]
        internal event EventHandler OnMouseDown;
        [DOM("onmousemove")]
        internal event EventHandler OnMouseMove;
        [DOM("onmouseout")]
        internal event EventHandler OnMouseOut;
        [DOM("onmouseover")]
        internal event EventHandler OnMouseOver;
        [DOM("onmouseup")]
        internal event EventHandler OnMouseUp;
        [DOM("onmousewheel")]
        internal event EventHandler OnMouseWheel;
        [DOM("onpaste")]
        internal event EventHandler OnPaste;
        [DOM("onpause")]
        internal event EventHandler OnPause;
        [DOM("onplay")]
        internal event EventHandler OnPlay;
        [DOM("onplaying")]
        internal event EventHandler OnPlaying;
        [DOM("onprogress")]
        internal event EventHandler OnProgress;
        [DOM("onratechange")]
        internal event EventHandler OnRateChange;
        [DOM("onreset")]
        internal event EventHandler OnReset;
        [DOM("onscroll")]
        internal event EventHandler OnScroll;
        [DOM("onseeked")]
        internal event EventHandler OnSeeked;
        [DOM("onseeking")]
        internal event EventHandler OnSeeking;
        [DOM("onselect")]
        internal event EventHandler OnSelect;
        [DOM("onstalled")]
        internal event EventHandler OnStalled;
        [DOM("onsubmit")]
        internal event EventHandler OnSubmit;
        [DOM("onsuspend")]
        internal event EventHandler OnSuspend;
        [DOM("ontimeout")]
        internal event EventHandler OnTimeOut;
        [DOM("ontimeupdate")]
        internal event EventHandler OnTimeUpdate;
        [DOM("ontouchcancel")]
        internal event EventHandler OnTouchCancel;
        [DOM("ontouchend")]
        internal event EventHandler OnTouchEnd;
        [DOM("ontouchmove")]
        internal event EventHandler OnTouchMove;
        [DOM("ontouchstart")]
        internal event EventHandler OnTouchStart;
        [DOM("onvolumechange")]
        internal event EventHandler OnVolumeChange;
        [DOM("onwaiting")]
        internal event EventHandler OnWaiting;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new Html document.
        /// </summary>
        internal HTMLDocument()
        {
            _contentType = MimeTypes.Xml;
            _ns = Namespaces.Html;
            _all = new HTMLLiveCollection<Element>(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a list of all elements in the document.
        /// </summary>
        public HTMLCollection All
        {
            get { return _all; }
        }

        /// <summary>
        /// Gets a list of all of the anchors in the document.
        /// </summary>
        [DOM("anchors")]
        public HTMLCollection Anchors
        {
            get { return _anchors ?? (_anchors = new HTMLLiveCollectionWithAttr<HTMLAnchorElement>(this, AttributeNames.NAME)); }
        }

        /// <summary>
        /// Gets or sets the direction of the document.
        /// </summary>
        public DirectionMode Dir
        {
            get 
            {
                var _documentElement = DocumentElement;
                return _documentElement != null ? _documentElement.Dir : DirectionMode.Ltr; 
            }
            set
            {
                var _documentElement = DocumentElement;

                if (_documentElement != null)
                    _documentElement.Dir = value;
            }
        }

        /// <summary>
        /// Gets the forms in the document.
        /// </summary>
        [DOM("forms")]
        public HTMLCollection Forms
        {
            get { return _forms ?? (_forms = new HTMLLiveCollection<HTMLFormElement>(this)); }
        }

        /// <summary>
        /// Gets the images in the document.
        /// </summary>
        [DOM("images")]
        public HTMLCollection Images
        {
            get { return _images ?? (_images = new HTMLLiveCollection<HTMLImageElement>(this)); }
        }

        /// <summary>
        /// Gets the scripts in the document.
        /// </summary>
        [DOM("scripts")]
        public HTMLCollection Scripts
        {
            get { return _scripts ?? (_scripts = new HTMLLiveCollection<HTMLScriptElement>(this)); }
        }

        /// <summary>
        /// Gets a list of the embedded OBJECTS within the current document.
        /// </summary>
        [DOM("embeds")]
        public HTMLCollection Embeds
        {
            get { return _embeds ?? (_embeds = new HTMLLiveCollection<HTMLEmbedElement, HTMLObjectElement, HTMLAppletElement>(this)); }
        }

        /// <summary>
        /// Gets a collection of all AREA elements and anchor elements in a document with a value for the href attribute.
        /// </summary>
        [DOM("links")]
        public HTMLCollection Links
        {
            get { return _links ?? (_links = new HTMLLiveCollectionWithAttr<HTMLAnchorElement, HTMLAreaElement>(this, AttributeNames.HREF)); }
        }

        /// <summary>
        /// Gets or sets the title of the document.
        /// </summary>
        [DOM("title")]
        public String Title
        {
            get
            {
                var _title = FindChild<HTMLTitleElement>(Head);

                if (_title != null)
                    return _title.Text;

                return String.Empty;
            }
            set
            {
                var _title = FindChild<HTMLTitleElement>(Head);

                if (_title == null)
                {
                    var _documentElement = DocumentElement;

                    if (_documentElement == null)
                    {
                        _documentElement = new HTMLHtmlElement();
                        AppendChild(_documentElement);
                    }

                    var _head = Head;

                    if (_head == null)
                    {
                        _head = new HTMLHeadElement();
                        _documentElement.AppendChild(_head);
                    }

                    _title = new HTMLTitleElement();
                    _head.AppendChild(_title);
                }

                _title.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the head element.
        /// </summary>
        [DOM("head")]
        public HTMLHeadElement Head
        {
            get { return FindChild<HTMLHeadElement>(DocumentElement); }
        }

        /// <summary>
        /// Gets the body element.
        /// </summary>
        [DOM("body")]
        public HTMLBodyElement Body
        {
            get { return FindChild<HTMLBodyElement>(DocumentElement); }
        }

        /// <summary>
        /// Gets a value to indicate whether the document is rendered in Quirks mode (BackComp) 
        /// or Strict mode (CSS1Compat).
        /// </summary>
        [DOM("compatMode")]
        public String CompatMode
        {
            get { return QuirksMode == QuirksMode.On ? "BackCompat" : "CSS1Compat"; }
        }

        /// <summary>
        /// Gets the cookie containing all cookies for the document or (re-)sets a single cookie.
        /// </summary>
        [DOM("cookie")]
        public Cookie Cookie
        { 
            get { return _cookie; }
            set { _cookie = value; }
        }

        /// <summary>
        /// Gets the domain portion of the origin of the current document.
        /// </summary>
        [DOM("domain")]
        public String Domain
        {
            get { return string.IsNullOrEmpty(DocumentURI) ? String.Empty : new Uri(DocumentURI).Host; }
        }

        /// <summary>
        /// Gets a string containing the URL of the current document.
        /// </summary>
        [DOM("URL")]
        public String URL
        {
            get { return DocumentURI; }
        }

        #endregion

        #region Internal properties

        /// <summary>
        /// Gets or sets if the document is embedded by an iframe srcdoc element.
        /// </summary>
        internal Boolean IsEmbedded
        {
            get { return _embedded; }
            set { _embedded = value; }
        }

        /// <summary>
        /// Gets or sets if scripting is active and allowed.
        /// </summary>
        internal Boolean IsScripting
        {
            get { return _scripting; }
            set { _scripting = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads a HTML document from the given URL.
        /// </summary>
        /// <param name="url">The URL that hosts the HTML content.</param>
        /// <returns>The document with the parsed content.</returns>
        public static HTMLDocument LoadFromURL(String url)
        {
            var doc = new HTMLDocument();
            return doc.Load(url);
        }

        /// <summary>
        /// Loads a HTML document from the given URL.
        /// </summary>
        /// <param name="source">The source code with the HTML content.</param>
        /// <returns>The document with the parsed content.</returns>
        public static HTMLDocument LoadFromSource(String source)
        {
            return DocumentBuilder.Html(source);
        }

        /// <summary>
        /// Loads the document content from the given URL.
        /// </summary>
        /// <param name="url">The URL that hosts the HTML content.</param>
        /// <returns>The document with the parsed content.</returns>
        [DOM("load")]
        public HTMLDocument Load(String url)
        {
            _location.Href = url;
            Cookie = new Cookie();

            for (int i = _children.Length - 1; i >= 0; i++)
                RemoveChild(_children[i]);

            ReadyState = Readiness.Loading;
            QuirksMode = QuirksMode.Off;
            var stream = Builder.Stream(url);
            var source = new SourceManager(stream);
            var parser = new HtmlParser(this, source);
            return parser.Result;
        }

        /// <summary>
        /// Returns a duplicate of the node on which this method was called.
        /// </summary>
        /// <param name="deep">Optional value: true if the children of the node should also be cloned, or false to clone only the specified node.</param>
        /// <returns>The duplicate node.</returns>
        [DOM("cloneNode")]
        public override Node CloneNode(Boolean deep = true)
        {
            var node = new HTMLDocument();
            CopyProperties(this, node, deep);
            CopyDocumentProperties(this, node, deep);
            node._embedded = this._embedded;
            node._scripting = this._scripting;
            return node;
        }

        /// <summary>
        /// Adopts a node from an external document. The node and its subtree is removed from
        /// the document it's in (if any), and its OwnerDocument is changed to the current document. 
        /// </summary>
        /// <param name="externalNode">The node from another document to be adopted.</param>
        /// <returns>The adopted node that can be used in the current document. </returns>
        [DOM("adoptNode")]
        public Node AdoptNode(Node externalNode)
        {
            if (externalNode.OwnerDocument != null)
            {
                if (externalNode.ParentNode != null)
                    externalNode.ParentNode.RemoveChild(externalNode);
            }

            externalNode.OwnerDocument = this;
            return externalNode;
        }

        /// <summary>
        /// Opens a document stream for writing.
        /// </summary>
        /// <returns>The current document.</returns>
        [DOM("open")]
        public HTMLDocument Open()
        {
            //TODO
            return this;
        }

        /// <summary>
        /// Finishes writing to a document.
        /// </summary>
        /// <returns>The current document.</returns>
        [DOM("close")]
        public HTMLDocument Close()
        {
            //TODO
            return this;
        }

        /// <summary>
        /// Writes text to a document.
        /// </summary>
        /// <param name="content">The text to be written on the document.</param>
        /// <returns>The current document.</returns>
        [DOM("write")]
        public HTMLDocument Write(String content)
        {
            //TODO
            return this;
        }

        /// <summary>
        /// Writes a line of text to a document.
        /// </summary>
        /// <param name="content">The text to be written on the document.</param>
        /// <returns>The current document.</returns>
        [DOM("writeln")]
        public HTMLDocument WriteLn(String content)
        {
            return Write(content + Specification.LF);
        }

        /// <summary>
        /// Creates a new element with the given tag name.
        /// </summary>
        /// <param name="tagName">A string that specifies the type of element to be created.</param>
        /// <returns>The created element object.</returns>
        [DOM("createElement")]
        public override Element CreateElement(String tagName)
        {
            var element = HTMLElement.Create(tagName.ToLower());
            element.OwnerDocument = this;
            return element;
        }

        /// <summary>
        /// Creates a new CDATA section node, and returns it.
        /// </summary>
        /// <param name="data">A string containing the data to be added to the CDATA Section.</param>
        /// <returns></returns>
        [DOM("createCDATASection")]
        public override CDATASection CreateCDATASection(String data)
        {
            throw new DOMException(ErrorCode.NotSupported);
        }

        /// <summary>
        /// Returns a list of elements with a given name in the HTML document.
        /// </summary>
        /// <param name="name">The value of the name attribute of the element.</param>
        /// <returns>A collection of HTML elements.</returns>
        [DOM("getElementsByName")]
        public HTMLCollection GetElementsByName(String name)
        {
            var result = new List<Element>();
            GetElementsByName(_children, name, result);
            return new HTMLStaticCollection(result);
        }

        #endregion

        #region Internals

        internal Int32 ScriptsWaiting { get { return 0; } }

        internal Int32 ScriptsAsSoonAsPossible { get { return 0; } }

        internal Boolean IsLoadingDelayed { get { return false; } }

        internal Boolean IsInBrowsingContext { get { return false; } }

        internal Boolean IsToBePrinted { get; set; }

        internal void SpinEventLoop()
        {
            //TODO
        }

        internal void RaiseDomContentLoaded()
        {
            //TODO
        }

        internal void RaiseLoadedEvent()
        {
            //TODO
        }

        internal void QueueTask(Action action)
        {
            //TODO
            //When a user agent is to queue a task, it must add the given task to one of the task queues of the relevant event loop.
            //All the tasks from one particular task source (e.g. the callbacks generated by timers, the events fired for mouse movements, the tasks queued for the
            //parser) must always be added to the same task queue, but tasks from different task sources may be placed in different task queues.
            //  For example, a user agent could have one task queue for mouse and key events (the user interaction task source), and another for everything else.
            //  The user agent could then give keyboard and mouse events preference over other tasks three quarters of the time, keeping the interface responsive
            //  but not starving other task queues, and never processing events from any one task source out of order.
            //Each task that is queued onto a task queue of an event loop defined by this specification is associated with a Document; if the task was queued in
            //the context of an element, then it is the element's Document; if the task was queued in the context of a browsing context, then it is the browsing
            //context's active document at the time the task was queued; if the task was queued by or for a script then the document is the script's document.
        }

        internal void Print()
        {
            //TODO
            //Run the printing steps.
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Reloads the document witht he given location.
        /// </summary>
        /// <param name="value">The value for reloading.</param>
        protected override void ReLoad(Location url)
        {
            Load(url.Href);
        }

        /// <summary>
        /// Gets a list of HTML elements given by their name attribute.
        /// </summary>
        /// <param name="children">The list to investigate.</param>
        /// <param name="name">The name attribute's value.</param>
        /// <param name="result">The result collection.</param>
        static void GetElementsByName(NodeList children, String name, List<Element> result)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i] is HTMLElement)
                {
                    var element = (HTMLElement)children[i];

                    if (element.GetAttribute(AttributeNames.NAME) == name)
                        result.Add(element);

                    GetElementsByName(element.ChildNodes, name, result);
                }
            }
        }

        #endregion
    }
}
