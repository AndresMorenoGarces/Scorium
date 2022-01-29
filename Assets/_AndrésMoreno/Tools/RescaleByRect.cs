using UnityEngine;
using UnityEngine.UI;

namespace AndresMoreno.Tools {
	[ExecuteAlways, RequireComponent(typeof(RectTransform))]
	public class RescaleByRect : MonoBehaviour {
		public RectTransform referenceRect;

		[Space(15), Header("Width Questions")]
		public bool isCopyWidth;
		public bool isUsingWidthMinLimit;
		public bool isUsingWidthMaxLimit;
		[Tooltip("Define if is implemented the max width, with his anchors, as an limit")] public bool isMaxWidthDefaultState;

		[Space(2), Header("Width Values")]
		public int widthOffset;
		public int widthMinLimit;
		[Tooltip("Only used if isMaxWidthDefaultState = false")] public int widthMaxLimit;

		[Space(15), Header("Heigth Questions")]
		public bool isCopyHeigth;
		public bool isUsingHeigthMinLimit;
		public bool isUsingHeigthMaxLimit;
		[Tooltip("Define if is implemented the max heigth, with his anchors, as an limit")] public bool isMaxHeigthDefaultState;

		[Space(2), Header("Heigth Values")]
		public int heigthOffset;
		public int heigthMinLimit;
		[Tooltip("Only used if isMaxHeigthDefaultState = false")] public int heigthMaxLimit;

		private RectTransform m_currentRect;
		private Vector2 m_currenSizeDelta;
		private Vector2 m_registeredScale;

		private void Awake() => m_currentRect = GetComponent<RectTransform>();
		private void LateUpdate() {
			if (referenceRect == null) return;

			if (m_currenSizeDelta != m_currentRect.sizeDelta && m_currentRect.anchoredPosition == Vector2.zero)
				m_currenSizeDelta = m_currentRect.sizeDelta;

			if (m_registeredScale == referenceRect.sizeDelta) return;
			else m_registeredScale = referenceRect.sizeDelta;

            if (isCopyWidth) {
				var resultWidth = m_registeredScale.x + widthOffset;
				resultWidth = isUsingWidthMinLimit && resultWidth > widthMinLimit ? widthMinLimit : resultWidth;
				var isExceedingTopWidth = false;
				if (isUsingWidthMaxLimit) {
					if (isMaxWidthDefaultState) {
						isExceedingTopWidth = resultWidth > m_currentRect.rect.width + Mathf.Abs(m_currenSizeDelta.x);
						resultWidth = isExceedingTopWidth ? 0 : resultWidth;
					} else { 
						isExceedingTopWidth = resultWidth > widthMaxLimit;
						resultWidth = isExceedingTopWidth ?  widthMaxLimit : resultWidth;

					}
				}
				if (isExceedingTopWidth)
					m_currentRect.sizeDelta = new(resultWidth, m_currentRect.sizeDelta.y);
				else
					m_currentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, resultWidth);
			}

			if (isCopyHeigth) {
				var resultHeigth = m_registeredScale.y + heigthOffset;
				resultHeigth = isUsingHeigthMinLimit && resultHeigth > heigthMinLimit ? heigthMinLimit : resultHeigth;
				var isExceedingTopHigth = false;
				if (isUsingHeigthMaxLimit) {
					if (isMaxHeigthDefaultState) {
						isExceedingTopHigth = resultHeigth > m_currentRect.rect.height + Mathf.Abs(m_currenSizeDelta.y);
						resultHeigth = isExceedingTopHigth ? 0 : resultHeigth;
					} else {
						isExceedingTopHigth = resultHeigth > heigthMaxLimit;
						resultHeigth = isExceedingTopHigth ? heigthMaxLimit : resultHeigth;
					}
				}
				if (isExceedingTopHigth)
					m_currentRect.sizeDelta = new(m_currentRect.sizeDelta.x, resultHeigth);
				else
					m_currentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, resultHeigth);
			}
		}
	}
}
